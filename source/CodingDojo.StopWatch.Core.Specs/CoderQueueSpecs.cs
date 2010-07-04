using System;
using System.Linq;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    [Concern(typeof (CoderQueue))]
    public abstract class ConcernOfCoderQueue : InstanceContextSpecification<CoderQueue>
    {
    }

    public class When_adding_a_coder_to_an_empty_queue : ConcernOfCoderQueue
    {
        private Coder coder1;

        protected override void EstablishContext()
        {
            coder1 = new Coder();
        }

        protected override void Because()
        {
            Sut.Enqueue(coder1);
        }

        [Observation]
        public void Should_count_is_1()
        {
            Sut.Count.ShouldBeEqualTo(1);
        }
    }

    public class When_adding_a_coder_to_a_queue_with_one_coder : ConcernOfCoderQueue
    {
        private Coder coder1;
        private Coder coder2;

        protected override void EstablishContext()
        {
            coder1 = new Coder();
            coder2 = new Coder();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.Enqueue(coder1);
            
        }
        protected override void Because()
        {
            Sut.Enqueue(coder2);
        }

        [Observation]
        public void Should_the_count_is_2()
        {
            Sut.Count.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_the_first_coder_is_coder1()
        {
            Sut.Dequeue().ShouldBeTheSame(coder1);
        }
    }

    [Concern(typeof(CoderQueue))]
    public abstract class ThreeCodersConcernOfCoderQueue : ConcernOfCoderQueue
    {
        protected Coder Coder1;
        protected Coder Coder2;
        protected Coder Coder3;

        protected override void EstablishContext()
        {
            Coder1 = new Coder();
            Coder2 = new Coder();
            Coder3 = new Coder();
        }

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.Enqueue(Coder1);
            Sut.Enqueue(Coder2);
            Sut.Enqueue(Coder3);
        }
    }

    public class When_dequeing_a_coder_from_a_queue_with_three_coders : ThreeCodersConcernOfCoderQueue
    {
        private Coder result;

        protected override void Because()
        {
            result = Sut.Dequeue();
        }

        [Observation]
        public void Should_should_the_count_is_2()
        {
            Sut.Count.ShouldBeEqualTo(2);
        }

        [Observation]
        public void Should_the_dequeued_coder_coder1()
        {
            result.ShouldBeTheSame(Coder1);
        }
    }

    public class When_dequeuing_a_coder_from_a_query_and_push_it_back : ThreeCodersConcernOfCoderQueue
    {
        protected override void Because()
        {
            var coder = Sut.Dequeue();
            Sut.Push(coder);
        }

        [Observation]
        public void Should_the_cound_is_3()
        {
            Sut.Count.ShouldBeEqualTo(3);
        }

        [Observation]
        public void Should_the_next_coder_is_coder1()
        {
            Sut.Dequeue().ShouldBeTheSame(Coder1);
        }
    }

    [Concern(typeof (CoderQueue))]
    public class When_dequeing_two_coder_from_a_queue_with_three_coders : ThreeCodersConcernOfCoderQueue
    {
        private Coder second;
        private Coder first;

        protected override void Because()
        {
            first = Sut.Dequeue();
            second = Sut.Dequeue();
        }

        [Observation]
        public void Should_the_first_coder_is_coder1()
        {
            first.ShouldBeTheSame(Coder1);
        }

        [Observation]
        public void Should_the_second_coder_is_coder2()
        {
            second.ShouldBeTheSame(Coder2);
        }

        [Observation]
        public void Should_the_count_is_1()
        {
            Sut.Count.ShouldBeEqualTo(1);
        }
    }

    [Concern(typeof (CoderQueue))]
    public class When_dequeue_and_enqueue_a_coder_from_a_queue_with_three_coders : ThreeCodersConcernOfCoderQueue
    {
        private Coder result;


        protected override void Because()
        {
            result = Sut.DequeueAndEnqueue();
        }

        [Observation]
        public void Should_the_dequeued_coder_is_coder1()
        {
            result.ShouldBeTheSame(Coder1);
        }

        [Observation]
        public void Should_the_count_is_3()
        {
            Sut.Count.ShouldBeEqualTo(3);
        }

        [Observation]
        public void Should_the_next_coder_in_the_queue_is_coder2()
        {
            var list = Sut.ToList();
            list[0].ShouldBeTheSame(Coder2);
        }

        [Observation]
        public void Should_the_second_coder_in_the_queue_is_coder3()
        {
            var list = Sut.ToList();
            list[1].ShouldBeTheSame(Coder3);
        }

        [Observation]
        public void Should_the_last_coder_is_coder1()
        {
            var list = Sut.ToList();
            list[2].ShouldBeTheSame(Coder1);
        }
    }

    [Concern(typeof (CoderQueue))]
    public class When_clearing_a_queue_with_three_coders : ThreeCodersConcernOfCoderQueue
    {
        protected override void Because()
        {
            Sut.Clear();
        }

        [Observation]
        public void Should_the_count_is_zero()
        {
            Sut.Count.ShouldBeEqualTo(0);
        }
    }
}