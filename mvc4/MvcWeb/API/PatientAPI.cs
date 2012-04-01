using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcActions.Patients;
using MvcAPI;
using MvcModel;

namespace MvcIOC.API
{
    public class PatientAPI : IPatientAPI
    {
        public GetPatientCollectionResult GetPatientCollectionResult(GetPatientCollectionRequest request)
        {
            GetPatientCollectionHandler handler = KernelInjection.GetService<GetPatientCollectionHandler>();
            return handler.Execute(request);
        }

        public GetPatientResult GetPatientResult(GetPatientRequest request)
        {
            GetPatientHandler handler = KernelInjection.GetService<GetPatientHandler>();
            return handler.Execute(request);
        }

        public CreatePatientResult CreatePatient(CreatePatientRequest request)
        {
            CreatePatientHandler handler = KernelInjection.GetService<CreatePatientHandler>();
            return handler.Execute(request);
        }

        public UpdatePatientResult UpdatePatient(UpdatePatientRequest request)
        {
            UpdatePatientHandler handler = KernelInjection.GetService<UpdatePatientHandler>();
            return handler.Execute(request);
        }

        public DeletePatientResult DeletePatient(DeletePatientRequest request)
        {
            DeletePatientHandler handler = KernelInjection.GetService<DeletePatientHandler>();
            return handler.Execute(request);
        }
    }
}