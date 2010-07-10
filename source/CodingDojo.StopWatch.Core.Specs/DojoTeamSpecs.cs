using System;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    public abstract class ConcernOfDojoTeam : InstanceContextSpecification<DojoTeam>
    {
        protected string PropertyChangedName;
        protected int PropertyChangeCount;

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.PropertyChanged += (sender, args) =>
            {
                PropertyChangedName = args.PropertyName;
                PropertyChangeCount++;
            };
        }
    }

    [Concern(typeof (DojoTeam))]
    public class When_getting_the_first_team_members : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void Because()
        {
            Sut.GetNextTeamMembers();
        }

        [Observation]
        public void Should_the_first_team_member_is_coder1()
        {
            Sut.CurrentTeamMembers[0].Name = "coder1";
        }

        [Observation]
        public void Should_the_second_team_member_is_coder2()
        {
            Sut.CurrentTeamMembers[1].Name = "coder2";
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_changed_propertychange_count_is_1()
        {
            PropertyChangeCount.ShouldBeEqualTo(1);
        }
        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }

    [Concern(typeof (DojoTeam))]
    public class When_getting_the_next_team_members_two_times : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void Because()
        {
            Sut.GetNextTeamMembers();
            Sut.GetNextTeamMembers();
        }

        [Observation]
        public void Should_the_first_team_member_is_coder2()
        {
            Sut.CurrentTeamMembers[0].Name = "coder2";
        }

        [Observation]
        public void Should_the_second_team_member_is_coder3()
        {
            Sut.CurrentTeamMembers[1].Name = "coder3";
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_changed_propertychange_count_is_2()
        {
            PropertyChangeCount.ShouldBeEqualTo(2);
        }
        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }

    public class GivenSixCoders : BehaviorConfigBase<DojoTeam>
    {
        protected override void PrepareSut(DojoTeam sut)
        {
            base.PrepareSut(sut);
            sut.Queue.Enqueue(new Coder("coder1"));
            sut.Queue.Enqueue(new Coder("coder2"));
            sut.Queue.Enqueue(new Coder("coder3"));
            sut.Queue.Enqueue(new Coder("coder4"));
            sut.Queue.Enqueue(new Coder("coder5"));
            sut.Queue.Enqueue(new Coder("coder6"));
        }
    }

    [Concern(typeof (DojoTeam))]
    public class When_pushback_coder1_from_the_first_team : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.GetNextTeamMembers();
        }

        protected override void Because()
        {
            Sut.PushbackTeamMember(0);
        }

        [Observation]
        public void Should_the_first_coder_is_coder2()
        {
            Sut.CurrentTeamMembers[0].Name.ShouldBeEqualTo("coder2");
        }

        [Observation]
        public void Should_the_second_coder_is_coder3()
        {
            Sut.CurrentTeamMembers[1].Name.ShouldBeEqualTo("coder3");
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_propertychangecount_is_2()
        {
            PropertyChangeCount.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }

    [Concern(typeof(DojoTeam))]
    public class When_pushback_coder1_from_the_first_team_and_getting_the_next_team : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.GetNextTeamMembers();
            Sut.PushbackTeamMember(0);
        }

        protected override void Because()
        {
            Sut.GetNextTeamMembers();
        }

        [Observation]
        public void Should_the_first_coder_is_coder3()
        {
            Sut.CurrentTeamMembers[0].Name.ShouldBeEqualTo("coder3");
        }

        [Observation]
        public void Should_the_second_coder_is_coder1()
        {
            Sut.CurrentTeamMembers[1].Name.ShouldBeEqualTo("coder1");
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_propertychangecount_is_3()
        {
            PropertyChangeCount.ShouldBeEqualTo(3);
        }

        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }

    [Concern(typeof(DojoTeam))]
    public class When_pushback_coder2_from_the_first_team : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.GetNextTeamMembers();
        }

        protected override void Because()
        {
            Sut.PushbackTeamMember(1);
        }

        [Observation]
        public void Should_the_first_coder_is_coder1()
        {
            Sut.CurrentTeamMembers[0].Name.ShouldBeEqualTo("coder1");
        }

        [Observation]
        public void Should_the_second_coder_is_coder3()
        {
            Sut.CurrentTeamMembers[1].Name.ShouldBeEqualTo("coder3");
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_propertychangecount_is_2()
        {
            PropertyChangeCount.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }


    [Concern(typeof(DojoTeam))]
    public class When_pushback_coder2_from_the_first_team_and_getting_the_next_team : ConcernOfDojoTeam
    {
        protected override void EstablishContext()
        {
            With<GivenSixCoders>();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.GetNextTeamMembers();
            Sut.PushbackTeamMember(1);
        }

        protected override void Because()
        {
            Sut.GetNextTeamMembers();
        }

        [Observation]
        public void Should_the_first_coder_is_coder3()
        {
            Sut.CurrentTeamMembers[0].Name.ShouldBeEqualTo("coder3");
        }

        [Observation]
        public void Should_the_second_coder_is_coder4()
        {
            Sut.CurrentTeamMembers[1].Name.ShouldBeEqualTo("coder2");
        }

        [Observation]
        public void Should_the_changed_propertyname_is_currentteeammembers()
        {
            PropertyChangedName.ShouldBeEqualTo("CurrentTeamMembers");
        }

        [Observation]
        public void Should_the_propertychangecount_is_3()
        {
            PropertyChangeCount.ShouldBeEqualTo(3);
        }

        [Observation]
        public void Should_should_be_6_coders_in_queue()
        {
            Sut.Queue.Count.ShouldBeEqualTo(6);
        }
    }

}