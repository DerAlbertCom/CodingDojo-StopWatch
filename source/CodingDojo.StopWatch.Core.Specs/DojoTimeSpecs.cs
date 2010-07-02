using System;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    public abstract class ConcernOfDojoTime : InstanceContextSpecification<DojoTime>
    {
        protected int TimeChangedCount;

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.TimeChanged += (sender, args) => TimeChangedCount++;
        }
    }

    [Concern(typeof (DojoTime))]
    public class When_dojotime_is_created: ConcernOfDojoTime
    {
        protected override void Because()
        {
            // Created Only
        }

        [Observation]
        public void Should_the_time_is_zero()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0, 0, 0));
        }
    }

    [Concern(typeof (DojoTime))]
    public class When_dojotime_is_increased : ConcernOfDojoTime
    {

        protected override void Because()
        {
            Sut.Increase();
        }

        [Observation]
        public void Should_the_dojotime_is_one_minute()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0,1,0));
        }

        [Observation]
        public void Should_the_time_changed_once()
        {
            TimeChangedCount.ShouldBeEqualTo(1);
        }
    }

    [Concern(typeof (DojoTime))]
    public class When_dojotime_is_increased_from_two_minutes : ConcernOfDojoTime
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.SetTime(new TimeSpan(0, 2, 0));
        }
        protected override void Because()
        {
            Sut.Increase();
        }

        [Observation]
        public void Should_the_time_is_three_minutes()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0,3,0));
        }

        [Observation]
        public void Should_the_timechanged_two_times()
        {
            TimeChangedCount.ShouldBeEqualTo(2);
        }
    }
    [Concern(typeof(DojoTime))]
    public class When_dojotime_is_decreased_from_two_minutes : ConcernOfDojoTime
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.SetTime(new TimeSpan(0, 2, 0));
        }
        protected override void Because()
        {
            Sut.Decrease();
        }

        [Observation]
        public void Should_the_time_is_one_minute()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0, 1, 0));
        }

        [Observation]
        public void Should_the_timechanged_two_times()
        {
            TimeChangedCount.ShouldBeEqualTo(2);
        }
    }

}