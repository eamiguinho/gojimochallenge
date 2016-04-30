using System.Collections.ObjectModel;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using GojimoChallenge.ViewModels.DataModels;

namespace GojimoChallenge.Android.Adapters
{
    public class SubjectAdapter : RecyclerView.Adapter
    {
        private ObservableCollection<SubjectDataModel> _subjects;

        public SubjectAdapter(ObservableCollection<SubjectDataModel> subjects)
        {
            _subjects = subjects;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as SubjectViewHolder;
            var subject = _subjects[position];
            if (vh != null)
            {
                vh.Name.Text = subject.Title;
                if(!string.IsNullOrWhiteSpace(subject.Colour))vh.Holder.SetBackgroundColor(Color.ParseColor(_subjects[position].Colour));
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.subject_item_template, parent, false);
            return new SubjectViewHolder(view);
        }

        public override int ItemCount { get { return _subjects.Count; } }

      
    }
}