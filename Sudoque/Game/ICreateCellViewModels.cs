namespace Sudoque.Game
{
    public interface ICreateCellViewModels
    {
        CellViewModel Create(NinerId id, int column, int row);
    }
}