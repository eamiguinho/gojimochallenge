using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace GojimoChallenge.Android.Adapters
{
    public class QualificationViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }

        public QualificationViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.qualification_name);
            itemView.Click += (sender, e) => listener(base.Position);

        }
    }
}