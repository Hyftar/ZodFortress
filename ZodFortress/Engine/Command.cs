namespace ZodFortress.Engine
{
    public class Command
    {
        public bool Success { get; set; }
        public string GameCommand { get; set; }
        public string Order { get; set; }
        public string Object { get; set; }
        public string Location { get; set; }

        public Command(bool Success = false, string GameCommand = "", string Order = "", string Object = "", string Location = "")
        {
            this.Success = Success;
            this.GameCommand = GameCommand;
            this.Object = Object;
            this.Order = Order;
            this.Location = Location;
        }
    }
}
