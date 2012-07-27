namespace Sudoque.Game
{
    public interface ICreateCellViewModels
    {
        CellViewModel Create(int ninerId, int cellId);
    }
}