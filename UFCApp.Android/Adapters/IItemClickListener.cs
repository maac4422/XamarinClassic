using Android.Views;

namespace UFCApp.Android.Adapters
{
    

    public interface IItemClickListener
    {
        void OnClick(View itemView, int position, bool isLongClick);
    }
}