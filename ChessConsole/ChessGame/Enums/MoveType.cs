namespace ChessConsole.ChessGame.Enums
{
    enum MoveType : int
    {
        // All
        Commun,
        Capture,

        // only Pawns
        DoubleStep,
        EnPassant,
        Promotion,

        // King
        CastleKing,
        CastleQueen,

    }
}
