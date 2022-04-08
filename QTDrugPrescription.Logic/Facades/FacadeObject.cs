//@CodeCopy
//MdStart

using QTDrugPrescription.Logic.Controllers;

namespace QTDrugPrescription.Logic.Facades
{
    public abstract class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
