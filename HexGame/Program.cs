namespace HexGame {
    internal static class Program {

        private static void Main() {
            using (var game = new GameImpl())
                game.Run();
        }

    }
}