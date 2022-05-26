using Events;
using UniRx;
using UnityEngine;

namespace UserInterface.Overlay
{
    public class HotbarView : MonoBehaviour
    {
        [SerializeField] private RectTransform holder;
        [SerializeField] private HotbarElementView hotbarElementViewPrefab;
        [SerializeField] private HotbarSystem hotbarSystem;

        private void Start()
        {
            DisplayCurrentHotbar();
            MessageBroker.Default
                .Receive<HotbarChanged>()
                .TakeUntilDestroy(this)
                .Subscribe(_ => DisplayCurrentHotbar());
        }

        private void DisplayCurrentHotbar()
        {
            foreach (var child in holder.gameObject.GetComponentsInChildren<HotbarElementView>())
            {
                Destroy(child.gameObject);
            }

            var all = hotbarSystem.GetAll();
            for (var index = 0; index < all.Count; index++)
            {
                var hotbarItemType = all[index];
                var hotbarElementView = Instantiate(hotbarElementViewPrefab, holder);
                var isActive = index == (int)hotbarSystem.GetActive();
                hotbarElementView.Display(hotbarItemType, isActive);
            }
        }
    }
}