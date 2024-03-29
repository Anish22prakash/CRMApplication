﻿using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;

namespace CustomerRelationshipManagementBackend.Service.SuppliersServices
{
    public interface ISupplierService
    {
        public Task<Suppliers?> AddSuppliersAsync(AddSupplierDto supplierDto);
        public Task<IList<Suppliers>> GetAllSuppliersAsync(int page, int pageSize, string? search , int userId);
        public Task<Suppliers> GetSuppliersAsync(int  supplierId , int userId);
        public Task<Suppliers> UpdateSuppliers(UpdateSupplierDto updatesupplierDto);
        public Task<string> DisabledSuppliers(int supplierId, int userId);
        public Task<string> DeleteSuppliers(int supplierId, int userId);
    }
}
