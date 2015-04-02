/* Options:
Date: 2015-03-25 10:43:24
Version: 1
BaseUrl: http://sivesw8x64:8088

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using BusinessLogic;
using Services;


namespace BusinessLogic
{

    public enum MethodStatus
    {
        Success,
        Fail,
        FatalError,
    }

    [DataContract]
    public partial class Part
    {
        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Groupid { get; set; }

        [DataMember]
        public virtual string Supplierid { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string TechnicalInfo { get; set; }

        [DataMember]
        public virtual int Quantity { get; set; }

        [DataMember]
        public virtual decimal CostPrice { get; set; }

        [DataMember]
        public virtual string Spare { get; set; }
    }

    [DataContract]
    public partial class ProductGroup
    {
        [DataMember]
        public virtual string GroupId { get; set; }

        [DataMember]
        public virtual string Description { get; set; }
    }

    [DataContract]
    public partial class Supplier
    {
        [DataMember]
        public virtual string SupplierId { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Address1 { get; set; }

        [DataMember]
        public virtual string Address2 { get; set; }

        [DataMember]
        public virtual string Address3 { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string PostalCode { get; set; }

        [DataMember]
        public virtual string WebAddress { get; set; }
    }
}

namespace Services
{

    [Route("/part", "POST")]
    public partial class PartCreate
        : IReturn<PartCreateResponse>
    {
        public virtual Part Part { get; set; }
    }

    public partial class PartCreateResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/part/{Grfa}", "DELETE")]
    public partial class PartDelete
        : IReturn<PartDeleteResponse>
    {
        public virtual string Grfa { get; set; }
    }

    public partial class PartDeleteResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/part/exist/{Id}", "GET")]
    public partial class PartExists
        : IReturn<PartExistsResponse>
    {
        public virtual string Id { get; set; }
    }

    public partial class PartExistsResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/part/{Id}", "GET")]
    public partial class PartRead
        : IReturn<PartReadResponse>
    {
        public virtual string Id { get; set; }
    }

    [Route("/part", "GET")]
    public partial class PartReadAll
        : IReturn<PartReadAllResponse>
    {
    }

    public partial class PartReadAllResponse
    {
        public PartReadAllResponse()
        {
            Parts = new List<Part>{};
        }

        public virtual MethodStatus Status { get; set; }
        public virtual List<Part> Parts { get; set; }
    }

    public partial class PartReadResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual Part Part { get; set; }
        public virtual string Grfa { get; set; }
    }

    [Route("/parts/supplier/{SupplierId}", "GET")]
    public partial class PartReadSupplierParts
        : IReturn<PartReadSupplierPartsResponse>
    {
        public virtual string SupplierId { get; set; }
    }

    public partial class PartReadSupplierPartsResponse
    {
        public PartReadSupplierPartsResponse()
        {
            Parts = new List<Part>{};
        }

        public virtual MethodStatus Status { get; set; }
        public virtual List<Part> Parts { get; set; }
    }

    [Route("/part", "PUT")]
    public partial class PartUpdate
        : IReturn<PartUpdateResponse>
    {
        public virtual Part Part { get; set; }
        public virtual string Grfa { get; set; }
    }

    public partial class PartUpdateResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual Part Part { get; set; }
        public virtual string Grfa { get; set; }
    }

    [Route("/productGroup", "POST")]
    public partial class ProductGroupCreate
        : IReturn<ProductGroupCreateResponse>
    {
        public virtual ProductGroup ProductGroup { get; set; }
    }

    public partial class ProductGroupCreateResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/productGroup/{Grfa}", "DELETE")]
    public partial class ProductGroupDelete
        : IReturn<ProductGroupDeleteResponse>
    {
        public virtual string Grfa { get; set; }
    }

    public partial class ProductGroupDeleteResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/productGroup/exist/{GroupId}", "GET")]
    public partial class ProductGroupExists
        : IReturn<ProductGroupExistsResponse>
    {
        public virtual string GroupId { get; set; }
    }

    public partial class ProductGroupExistsResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/productGroup/{GroupId}", "GET")]
    public partial class ProductGroupRead
        : IReturn<ProductGroupReadResponse>
    {
        public virtual string GroupId { get; set; }
    }

    [Route("/productGroup", "GET")]
    public partial class ProductGroupReadAll
        : IReturn<ProductGroupReadAllResponse>
    {
    }

    public partial class ProductGroupReadAllResponse
    {
        public ProductGroupReadAllResponse()
        {
            ProductGroups = new List<ProductGroup>{};
        }

        public virtual MethodStatus Status { get; set; }
        public virtual List<ProductGroup> ProductGroups { get; set; }
    }

    public partial class ProductGroupReadResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual string Grfa { get; set; }
    }

    [Route("/productGroup", "PUT")]
    public partial class ProductGroupUpdate
        : IReturn<ProductGroupUpdateResponse>
    {
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual string Grfa { get; set; }
    }

    public partial class ProductGroupUpdateResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual string Grfa { get; set; }
    }

    [Route("/supplier", "POST")]
    public partial class SupplierCreate
        : IReturn<SupplierCreateResponse>
    {
        public virtual Supplier Supplier { get; set; }
    }

    public partial class SupplierCreateResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/supplier/{Grfa}", "DELETE")]
    public partial class SupplierDelete
        : IReturn<SupplierDeleteResponse>
    {
        public virtual string Grfa { get; set; }
    }

    public partial class SupplierDeleteResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/supplier/exist/{SupplierId}", "GET")]
    public partial class SupplierExists
        : IReturn<SupplierExistsResponse>
    {
        public virtual string SupplierId { get; set; }
    }

    public partial class SupplierExistsResponse
    {
        public virtual MethodStatus Status { get; set; }
    }

    [Route("/supplier/{SupplierId}", "GET")]
    public partial class SupplierRead
        : IReturn<SupplierReadResponse>
    {
        public virtual string SupplierId { get; set; }
    }

    [Route("/supplier", "GET")]
    public partial class SupplierReadAll
        : IReturn<SupplierReadAllResponse>
    {
    }

    public partial class SupplierReadAllResponse
    {
        public SupplierReadAllResponse()
        {
            Suppliers = new List<Supplier>{};
        }

        public virtual MethodStatus Status { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }

    public partial class SupplierReadResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual string Grfa { get; set; }
    }

    [Route("/supplier", "PUT")]
    public partial class SupplierUpdate
        : IReturn<SupplierUpdateResponse>
    {
        public virtual Supplier Supplier { get; set; }
        public virtual string Grfa { get; set; }
    }

    public partial class SupplierUpdateResponse
    {
        public virtual MethodStatus Status { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual string Grfa { get; set; }
    }
}

