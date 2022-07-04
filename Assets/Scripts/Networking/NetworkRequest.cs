using System;
using System.Collections;
using System.Text;
using Networking.Requests;
using Newtonsoft.Json;
using ScriptableObjectSystems;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
	public class NetworkRequest : MonoBehaviour
	{
		public const string GameServerBaseUrl = "http://localhost:8080/";
		public const string MathQuestionsBaseUrl = "https://math-questions-backend.herokuapp.com/";

		public static void HandleNetworkRequest(INetworkRequest request)
		{
			switch (request.Method)
			{
				case Method.Post:
					FindObjectOfType<NetworkRequest>().StartCoroutine(
						PostRequestJson(request.BasePath + request.Path,
							JsonConvert.SerializeObject(request.RequestBody))
					);
					break;
				case Method.Get:
					FindObjectOfType<NetworkRequest>().StartCoroutine(
						GetRequest(request.BasePath + request.Path)
					);
					break;
			}
			// TODO: add+test other methods
		}

		private static IEnumerator PostRequestJson(string url, string json)
		{
			var request = new UnityWebRequest(url, "POST");
			byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
			request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
			request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			request.SetRequestHeader("Content-Type", "application/json");
			yield return request.SendWebRequest();
			Debug.Log(request.downloadHandler.text);
		}

		private static IEnumerator PutRequest(string uri, string jsonBody)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(jsonBody);
			using UnityWebRequest www = UnityWebRequest.Put(uri, bytes);
			www.SetRequestHeader("Content-Type", "application/json");

			yield return www.Send();

			if (www.isNetworkError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.downloadHandler.text);
			}
		}

		private static IEnumerator GetRequest(string uri)
		{
			using var webRequest = UnityWebRequest.Get(uri);
			yield return webRequest.SendWebRequest();

			var pages = uri.Split('/');
			var page = pages.Length - 1;

			switch (webRequest.result)
			{
				case UnityWebRequest.Result.ConnectionError:
				case UnityWebRequest.Result.DataProcessingError:
					Debug.LogError(pages[page] + ": Error: " + webRequest.error);
					break;
				case UnityWebRequest.Result.ProtocolError:
					Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
					break;
				case UnityWebRequest.Result.Success:
					Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
					break;
			}
		}

		public static void Create(NetworkObject networkObject)
		{
			FindObjectOfType<NetworkRequest>().StartCoroutine(networkObject.GetRequest());
		}
	}

	public class NetworkObject
	{
		public INetworkRequest request;
		private string result;
		public Action<string> doneCallback;

		// TODO: other verbs, e.g. POST request
		public IEnumerator GetRequest()
		{
			var www = UnityWebRequest.Get(request.BasePath + request.Path);
			yield return www.SendWebRequest();
			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				result = www.downloadHandler.text;
				doneCallback(result);
			}
		}
	}
}
