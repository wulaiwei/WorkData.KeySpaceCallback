// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service.Domain
// 文件名：UserBaseService.cs
// 创建标识：吴来伟 2018-03-29 14:51
// 创建描述：
//  
// 修改标识：吴来伟2018-03-29 14:51
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Dapper;
using WorkData.Service.Domain.UserBases.Dtos;

namespace WorkData.Service.Domain.UserBases.Services
{
    public class UserBaseService: IUserBaseService
    {
        /// <summary>
        /// AddUserBase
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public UserBase AddUserBase(UserBase entity)
        {
            using (var db = DbContext.CreateInstance())
            {
                var result=  db.Insert(entity);
                return entity;
            }
        }

        public UserBase GetUserBase(string key)
        {
            throw new System.NotImplementedException();
        }

        public UserBase VerificationUserBase(VerificationUserBaseInputDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}