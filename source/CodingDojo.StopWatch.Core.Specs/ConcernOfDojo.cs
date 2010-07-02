using System;
using System.ComponentModel;
using Xunit;

namespace CodingDojo.StopWatch.Core.Specs
{
    public abstract class ConcernOfDojo : InstanceContextSpecification<Dojo>
    {
        protected int PropertyChangedCount;
        protected string PropertyChangedName;

        protected override void PrepareSut()
        {
            base.PrepareSut();
            Sut.PropertyChanged += SutOnPropertyChanged;
        }

        private void SutOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChangedCount++;
            PropertyChangedName = propertyChangedEventArgs.PropertyName;
        }

        protected override void AfterEachObservation()
        {
            base.AfterEachObservation();
            Sut.PropertyChanged -= SutOnPropertyChanged;
        }
    }
}