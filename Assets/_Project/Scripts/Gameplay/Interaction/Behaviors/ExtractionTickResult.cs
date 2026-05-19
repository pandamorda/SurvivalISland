namespace _Project.Scripts.Gameplay.Interaction.Behaviors
{
    public readonly struct ExtractionTickResult
    {
        public ExtractionStatus Status { get; }
        public float Progress { get; }

        public ExtractionTickResult(ExtractionStatus status, float progress)
        {
            Progress = progress;
            Status = status;
        }
    }
}