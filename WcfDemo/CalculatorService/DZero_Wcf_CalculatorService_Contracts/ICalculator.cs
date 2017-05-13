using System.Runtime.Serialization;
using System.ServiceModel;

namespace DZero_Wcf_CalculatorService_Contracts
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。

    [ServiceContract(Name = "CalculatorService")]//服务契约
    public interface ICalculator
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: 在此添加您的服务操作
        [OperationContract(Name = "Add")]
        double Add(double x, double y);

        [OperationContract(Name = "Subtract")]
        double Subtract(double x, double y);

        [OperationContract(Name = "Multiply")]
        double Multiply(double x, double y);

        [OperationContract(Name = "Divide")]
        double Divide(double x, double y);
    }

    //// 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    //// 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“DZero_Wcf_CalculatorService_Contracts.ContractType”直接使用其中定义的数据类型。
    //[DataContract]    //【数据契约】
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
