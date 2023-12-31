// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/customer.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ServerApp {
  public static partial class Customers
  {
    static readonly string __ServiceName = "customer.Customers";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.CreateCustomerRequest> __Marshaller_customer_CreateCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.CreateCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.CreateCustomerResponse> __Marshaller_customer_CreateCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.CreateCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.GetCustomerRequest> __Marshaller_customer_GetCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.GetCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.GetCustomerResponse> __Marshaller_customer_GetCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.GetCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.GetCustomersRequest> __Marshaller_customer_GetCustomersRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.GetCustomersRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ServerApp.GetCustomersResponse> __Marshaller_customer_GetCustomersResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ServerApp.GetCustomersResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ServerApp.CreateCustomerRequest, global::ServerApp.CreateCustomerResponse> __Method_CreateCustomer = new grpc::Method<global::ServerApp.CreateCustomerRequest, global::ServerApp.CreateCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateCustomer",
        __Marshaller_customer_CreateCustomerRequest,
        __Marshaller_customer_CreateCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ServerApp.GetCustomerRequest, global::ServerApp.GetCustomerResponse> __Method_GetCustomer = new grpc::Method<global::ServerApp.GetCustomerRequest, global::ServerApp.GetCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCustomer",
        __Marshaller_customer_GetCustomerRequest,
        __Marshaller_customer_GetCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ServerApp.GetCustomersRequest, global::ServerApp.GetCustomersResponse> __Method_GetCustomers = new grpc::Method<global::ServerApp.GetCustomersRequest, global::ServerApp.GetCustomersResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCustomers",
        __Marshaller_customer_GetCustomersRequest,
        __Marshaller_customer_GetCustomersResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ServerApp.CustomerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Customers</summary>
    [grpc::BindServiceMethod(typeof(Customers), "BindService")]
    public abstract partial class CustomersBase
    {
      /// <summary>
      /// Create
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ServerApp.CreateCustomerResponse> CreateCustomer(global::ServerApp.CreateCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Read
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ServerApp.GetCustomerResponse> GetCustomer(global::ServerApp.GetCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ServerApp.GetCustomersResponse> GetCustomers(global::ServerApp.GetCustomersRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CustomersBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CreateCustomer, serviceImpl.CreateCustomer)
          .AddMethod(__Method_GetCustomer, serviceImpl.GetCustomer)
          .AddMethod(__Method_GetCustomers, serviceImpl.GetCustomers).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CustomersBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CreateCustomer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ServerApp.CreateCustomerRequest, global::ServerApp.CreateCustomerResponse>(serviceImpl.CreateCustomer));
      serviceBinder.AddMethod(__Method_GetCustomer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ServerApp.GetCustomerRequest, global::ServerApp.GetCustomerResponse>(serviceImpl.GetCustomer));
      serviceBinder.AddMethod(__Method_GetCustomers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ServerApp.GetCustomersRequest, global::ServerApp.GetCustomersResponse>(serviceImpl.GetCustomers));
    }

  }
}
#endregion
