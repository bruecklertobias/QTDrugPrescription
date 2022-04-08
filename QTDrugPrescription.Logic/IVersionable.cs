//@CodeCopy
//MdStart

namespace QTDrugPrescription.Logic
{
    public interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
