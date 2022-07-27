namespace Events
{
	public struct ShowUi
	{
		public UiType type;
	}

	public enum UiType
	{
		None,
		GameOverScreen,
	}
}
