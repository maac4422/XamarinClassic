namespace UFCApp.Droid.Adapters
{
    using Android.Views;

    public interface IItemClickListener
    {
        void OnClick(View itemView,int position,bool isLongClick);
    }
}