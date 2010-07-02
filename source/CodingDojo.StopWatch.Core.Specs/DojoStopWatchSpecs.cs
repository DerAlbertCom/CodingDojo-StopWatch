using System;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    public abstract class ConcernOfDojoStopWatch : InstanceContextSpecification<DojoStopWatch>
    {
        protected IDojoTime RoundTimeSixMinutes;
        protected int TimeChangedCount;

        protected override void EstablishContext()
        {
            RoundTimeSixMinutes = An<IDojoTime>();
            RoundTimeSixMinutes.WhenToldTo(rt => rt.Time).Return(new TimeSpan(0, 6, 0));
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.TimeChanged += (source, args) => TimeChangedCount++;
        }
    }

    [Concern(typeof (DojoStopWatch))]
    public class When_the_stopwatch_is_started_with_a_six_minute_round : ConcernOfDojoStopWatch
    {
        protected override void Because()
        {
            Sut.StartRound(RoundTimeSixMinutes);
        }

        [Observation]
        public void Should_the_remainingtime_six_minutes()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0, 6, 0));
        }

        [Observation]
        public void Should_the_timechanged_event_fired_once()
        {
            TimeChangedCount.ShouldBeEqualTo(1);
        }
    }

    [Concern(typeof (DojoStopWatch))]
    public class When_the_time_is_increased_from_a_starttime_of_six_minutes : ConcernOfDojoStopWatch
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.StartRound(RoundTimeSixMinutes);
        }

        protected override void Because()
        {
            Sut.Increase();
        }

        [Observation]
        public void Should_the_remaining_time_should_be_seven_minutes()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0, 7, 0));
        }

        [Observation]
        public void Should_the_timechanged_event_fired_two_times()
        {
            TimeChangedCount.ShouldBeEqualTo(2);
        }
    }


    [Concern(typeof (DojoStopWatch))]
    public class When_the_time_is_decreased_from_a_starttime_of_six_minutes : ConcernOfDojoStopWatch
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.StartRound(RoundTimeSixMinutes);
        }

        protected override void Because()
        {
            Sut.Decrease();
        }

        [Observation]
        public void Should_the_remaining_time_should_be_five_minutes()
        {
            Sut.Time.ShouldBeEqualTo(new TimeSpan(0, 5, 0));
        }

        [Observation]
        public void Should_the_timechanged_event_fired_two_times()
        {
            TimeChangedCount.ShouldBeEqualTo(2);
        }
    }
}