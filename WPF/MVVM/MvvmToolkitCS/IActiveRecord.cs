using System;

namespace MvvmToolkit
{
    /// <summary>
    /// 
    /// </summary>
    interface IActiveRecord
    {
        /// <summary>
        /// Create a new record in the underlying database
        /// </summary>
        /// <returns></returns>
        bool Create();

        /// <summary>
        /// Update the existing record in the underlying database
        /// </summary>
        /// <returns></returns>
        bool Update();

        /// <summary>
        /// Delete the record in the underlying database
        /// </summary>
        /// <returns></returns>
        bool Delete();

    }
}
