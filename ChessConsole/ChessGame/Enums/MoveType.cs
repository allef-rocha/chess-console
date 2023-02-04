namespace ChessConsole.ChessGame.Enums
{
    enum MoveType : int
    {
        // All
        Commun,

        // only Pawns
        DoubleStep,
        EnPassant,
        Promotion,

        // King
        CastleKing,
        CastleQueen,

    }
}
