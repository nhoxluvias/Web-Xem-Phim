﻿using Data.DAL;
using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.BLL
{
    public class RoleBLL : BusinessLogicLayer
    {
        private DataAccessLevel dataAccessLevel;
        public RoleBLL(DataAccessLevel dataAccessLevel)
            : base()
        {
            InitDAL();
            this.dataAccessLevel = dataAccessLevel;
        }

        public RoleBLL(BusinessLogicLayer bll, DataAccessLevel dataAccessLevel)
            : base()
        {
            InitDAL(bll.db);
            this.dataAccessLevel = dataAccessLevel;
        }

        private RoleInfo ToRoleInfo(Role role)
        {
            if (role == null)
                throw new Exception("");
            return new RoleInfo
            {
                ID = role.ID,
                name = role.name,
                createAt = role.createAt,
                updateAt = role.updateAt
            };
        }

        private Role ToRole(RoleCreation roleCreation)
        {
            if (roleCreation == null)
                throw new Exception("");
            return new Role
            {
                ID = roleCreation.ID,
                name = roleCreation.name,
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            };
        }

        private Role ToRole(RoleUpdate roleUpdate)
        {
            if (roleUpdate == null)
                throw new Exception("");
            return new Role
            {
                ID = roleUpdate.ID,
                name = roleUpdate.name,
                updateAt = DateTime.Now
            };
        }

        public async Task<List<RoleInfo>> GetRolesAsync()
        {
            List<RoleInfo> roles = null;
            if(dataAccessLevel == DataAccessLevel.Admin)
                roles = (await db.Roles.ToListAsync())
                    .Select(c => ToRoleInfo(c)).ToList();
            else
                roles = (await db.Roles.ToListAsync(c => new { c.name }))
                    .Select(c => ToRoleInfo(c)).ToList();
            return roles;
        }

        public async Task<RoleInfo> GetRoleAsync(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
                throw new Exception("");
            Role role = null;
            if(dataAccessLevel == DataAccessLevel.Admin)
                role = (await db.Roles.SingleOrDefaultAsync(c => c.ID == roleId));
            else
                role = (await db.Roles.SingleOrDefaultAsync(c => new { c.name }, c => c.ID == roleId));

            return ToRoleInfo(role);
        }

        public async Task<bool> CreateRoleAsync(RoleCreation roleCreation)
        {
            if (dataAccessLevel == DataAccessLevel.User)
                throw new Exception("");
            Role role = ToRole(roleCreation);
            if (role.name == null)
                throw new Exception("");

            int affected = await db.Roles.InsertAsync(role);

            return (affected != 0);
        }

        public async Task<bool> UpdateRoleAsync(RoleUpdate roleUpdate)
        {
            if (dataAccessLevel == DataAccessLevel.User)
                throw new Exception("");
            Role role = ToRole(roleUpdate);
            if (role.name == null)
                throw new Exception("");

            int affected = await db.Roles
                .UpdateAsync(role, r => new { r.name, r.updateAt }, r => r.ID == role.ID);

            return (affected != 0);
        }

        public async Task<bool> DeleteAsync(string roleId)
        {
            if (dataAccessLevel == DataAccessLevel.User)
                throw new Exception("");
            if (string.IsNullOrEmpty(roleId))
                throw new Exception("");

            long userNumberOfRoleId = await db.Users.CountAsync(r => r.roleId == roleId);
            if (userNumberOfRoleId > 0)
                return false;

            int affected = await db.Roles.DeleteAsync(r => r.ID == roleId);
            return (affected != 0);
        }

        public async Task<int> CountAllAsync()
        {
            return (int)await db.Roles.CountAsync();
        }
    }
}
