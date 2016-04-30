using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace GojimoChallenge.Android.Adapters
{
    public class SubjectViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public RelativeLayout Holder { get; private set; }

        public SubjectViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.subject_name);
            Holder = itemView.FindViewById<RelativeLayout>(Resource.Id.subject_holder);
        }
    }
}