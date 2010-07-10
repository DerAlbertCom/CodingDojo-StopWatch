using System;
using System.Threading;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    [Concern(typeof(DojoUpdatingTimer))]
    public class When_starting_a_timer_with_an_inteveral_of_20_ms : InstanceContextSpecification<DojoUpdatingTimer>
    {
        private int updatedCount;

        protected override void EstablishContext()
        {
            base.EstablishContext();
            The<IUpdating>().WhenToldTo(u => u.Update()).Callback(() => updatedCount++);
        }
        protected override DojoUpdatingTimer CreateSut()
        {
            return new DojoUpdatingTimer(The<IUpdating>(), 100.0);
        }

        protected override void Because()
        {
            Sut.Start();
        }

        [Observation]
        public void Should_the_update_calls_1_time_in_180_ms()
        {
            Sut.Start();
            Thread.Sleep(180);
            Sut.Stop();
            updatedCount.ShouldBeEqualTo(1);
        }

        [Observation]
        public void Should_the_update_calls_3_time_in_380_ms()
        {
            Sut.Start();
            Thread.Sleep(380);
            Sut.Stop();
            updatedCount.ShouldBeEqualTo(3);
        }

        [Observation]
        public void Should_the_update_calls_1_time_in_380_ms_if_stopped_after_180_ms()
        {
            Sut.Start();
            Thread.Sleep(180);
            Sut.Stop();
            Thread.Sleep(200);
            updatedCount.ShouldBeEqualTo(1);
        }
    }
}