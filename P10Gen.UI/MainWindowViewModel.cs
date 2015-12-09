using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using P10Gen.Core.Model;
using P10Gen.Core.Services;

namespace P10Gen.UI
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(CreateTenPhases createTenPhases)
        {
            Phases = createTenPhases.Execute(75m);
        }

        public IEnumerable<Phase> Phases { get; set; }
    }
}