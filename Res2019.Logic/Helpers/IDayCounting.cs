namespace Res2019
{
    public interface IDayCounting
    {
        string SetPreviousOrNextDay(string dateIn, int dayToMove);
        string SetCurrentDate();
    }
}