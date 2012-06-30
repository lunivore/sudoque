namespace Sudoque.Game
{
    public interface ICreateCells
    {
        CellViewModel Create(NinerId id, int column, int row);
    }
}