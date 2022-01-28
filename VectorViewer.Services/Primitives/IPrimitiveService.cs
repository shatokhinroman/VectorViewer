namespace VectorViewer.Services.Primitives
{
    using System.Collections.Generic;
    using Model.OperationResult;
    using Model.Primitives.Base;

    public interface IPrimitiveService
    {
        Dictionary<OperationResult, Primitive> GetPrimitives(string filePath);
    }
}