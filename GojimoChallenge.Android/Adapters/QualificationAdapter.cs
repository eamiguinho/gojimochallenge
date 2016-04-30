using System;
using System.Collections.ObjectModel;
using Android.Support.V7.Widget;
using Android.Views;
using GojimoChallenge.ViewModels.DataModels;

namespace GojimoChallenge.Android.Adapters
{
    public class QualificationAdapter : RecyclerView.Adapter
    {
        private ObservableCollection<QualificationDataModel> _qualifications;
        public event EventHandler<int> ItemClick;

        public QualificationAdapter(ObservableCollection<QualificationDataModel> qualifications)
        {
            _qualifications = qualifications;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as QualificationViewHolder;
            if (vh != null) vh.Name.Text = _qualifications[position].Name;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.qualification_item_template, parent, false);
            return new QualificationViewHolder(view, OnClick);
        }

        public override int ItemCount { get { return _qualifications.Count; } }

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}