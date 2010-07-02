using System;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    [Concern(typeof (Dojo), "Setting up a CodingDojo")]
    public class When_adding_a_coder_to_a_dojo : ConcernOfDojo
    {
        protected override void Because()
        {
            Sut.AddCoder(new Coder());
        }

        [Observation]
        public void Should_the_coder_count_be_1()
        {
            Sut.CodersCount.ShouldBeEqualTo(1);
        }

        [Observation]
        public void Should_the_property_changed_count_is_1()
        {
            PropertyChangedCount.ShouldBeEqualTo(1);
        }

        [Observation]
        public void Should_the_changed_property_name_is_coderscount()
        {
            PropertyChangedName.ShouldBeEqualTo("CodersCount");
        }
    }

    [Concern(typeof (Dojo), "Setting up a CodingDojo")]
    public class When_adding_a_minute_of_team_time : ConcernOfDojo
    {
        protected override void Because()
        {
            Sut.IncreaseTeamTime();
        }

        [Observation]
        public void Should_the_team_time_increased_for_one_minute()
        {
            Sut.TeamTime.ShouldBeEqualTo(new TimeSpan(0, 1, 0));
        }

        [Observation]
        public void Should_the_property_changed_count_is_1()
        {
            PropertyChangedCount.ShouldBeEqualTo(1);
        }

        [Observation]
        public void Should_the_changed_property_name_is_coderscount()
        {
            PropertyChangedName.ShouldBeEqualTo("TeamTime");
        }

    }

    [Concern(typeof (Dojo))]
    public class When_adding_a_minute_of_team_time_to_an_existing_time : ConcernOfDojo
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.SetTeamTime(new TimeSpan(0, 7, 0));
        }
        protected override void Because()
        {
            Sut.IncreaseTeamTime();
        }

        [Observation]
        public void Should_the_team_time_increased_for_one_minute()
        {
            Sut.TeamTime.ShouldBeEqualTo(new TimeSpan(0,8,0));
        }
        [Observation]
        public void Should_the_property_changed_count_is_2()
        {
            PropertyChangedCount.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_the_changed_property_name_is_coderscount()
        {
            PropertyChangedName.ShouldBeEqualTo("TeamTime");
        }
    }

    [Concern(typeof (Dojo))]
    public class When_removing_a_minute_of_time_time_to_an_existing_time : ConcernOfDojo
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.SetTeamTime(new TimeSpan(0,7,0));
        }

        protected override void Because()
        {
            Sut.DecreaseTeamTime();
        }

        [Observation]
        public void Should_the_team_decreased_for_one_minute()
        {
            Sut.TeamTime.ShouldBeEqualTo(new TimeSpan(0,6,0));
        }

        [Observation]
        public void Should_the_property_changed_count_is_2()
        {
            PropertyChangedCount.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_the_changed_property_name_is_coderscount()
        {
            PropertyChangedName.ShouldBeEqualTo("TeamTime");
        }
    }

    [Concern(typeof (Dojo))]
    public class When_removing_a_minute_from_less_a_minute_team_time : ConcernOfDojo
    {
        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.SetTeamTime(new TimeSpan(0,0,10));
        }
        protected override void Because()
        {
            Sut.DecreaseTeamTime();
        }

        [Observation]
        public void Should_the_team_time_zero()
        {
            Sut.TeamTime.ShouldNotBeEqualTo(new TimeSpan(0,0,0));
        }
    }
}