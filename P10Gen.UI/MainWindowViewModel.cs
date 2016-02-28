using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using P10Gen.UI.Annotations;
using P10GenContracts.Model;

namespace P10Gen.UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            
        }

        private async Task<IEnumerable<Phase>> CreatePhases()
        {
            var client = new HttpClient();
            // New code:
            client.BaseAddress = new Uri("http://p10genonline.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/values");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Phase>>();
            }

            return new List<Phase>();
        }

        public IEnumerable<Phase> Phases { get; set; }

        public void NewPhases()
        {
            Task.Factory.StartNew(NewPhasesInner);
        }

        public void NewPhasesInner()
        {
            Phases = CreatePhases().Result;
            OnPropertyChanged(nameof(Phases));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}