using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    [Concern(typeof (Coder))]
    public class When_setting_the_name_to_albert_weinert : InstanceContextSpecification<Coder>
    {
        private string propertyName;
        private int propertyChangedCount;

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.PropertyChanged += (sender, args) =>
            {
                propertyChangedCount++;
                propertyName = args.PropertyName;
            };
        }

        protected override void Because()
        {
            Sut.Name = "Albert Weinert";
        }

        protected override Coder CreateSut()
        {
            return new Coder("initname");
        }
        [Observation]
        public void Should_the_propertychanged_event_should_raised()
        {
            propertyChangedCount.ShouldBeEqualTo(1);
        }

        [Observation]
        public void Should_the_propertychanged_propertyname_is_name()
        {
            propertyName.ShouldBeEqualTo("Name");
        }

        [Observation]
        public void Should_the_name_should_be_albert_weinert()
        {
            Sut.Name.ShouldBeEqualTo("Albert Weinert");
        }
    }
}