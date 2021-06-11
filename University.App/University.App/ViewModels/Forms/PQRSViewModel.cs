using System.Collections.Generic;
using University.App.Helpers;

namespace University.App.ViewModels.Forms
{
    public class PQRSViewModel : BaseViewModel
    {
        #region Attributes
        public class TypeRequest
        {
            public string Name { get; set; }
            public string Name1 { get; set; }
        }
        private List<TypeRequest> _typeRequests;
        private List<TypeRequest> _typeRequests1;
        #endregion

        #region Properties
        public List<TypeRequest> TypeRequests
        {
            get { return this._typeRequests; }
            set { this.SetValue(ref this._typeRequests, value); }
        }
        #endregion

        #region Properties
        public List<TypeRequest> TypeRequests1
        {
            get { return this._typeRequests1; }
            set { this.SetValue(ref this._typeRequests1, value); }
        }
        #endregion

        #region Constructor
        public PQRSViewModel()
        {
            this.LoadTypeRequests();
            this.LoadTypeRequests1();
        }
        #endregion

        #region Methods
        private void LoadTypeRequests()
        {
            this.TypeRequests = new List<TypeRequest>
            {
                new TypeRequest { Name = Languages.Petition },
                new TypeRequest { Name = Languages.Complain },
                new TypeRequest { Name = Languages.Claim },
                new TypeRequest { Name = Languages.Suggestion }
            };
        }
        #endregion

        #region Methods
        private void LoadTypeRequests1()
        {
            this.TypeRequests1 = new List<TypeRequest>
            {
                new TypeRequest { Name1 = Languages.Bad },
                new TypeRequest { Name1 = Languages.Regular },
                new TypeRequest { Name1 = Languages.Well },
                new TypeRequest { Name1 = Languages.Acceptable },
                new TypeRequest { Name1 = Languages.Excellent }
            };
        }
        #endregion
    }
}