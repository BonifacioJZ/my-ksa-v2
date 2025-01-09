using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    /// <summary>
    /// Clase que representa la paginación de una lista de elementos.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la lista.</typeparam>
    public class Pagination<T> : List<T>
    {
        /// <summary>
        /// Página inicial.
        /// </summary>
        public int initPage { get; private set; }

        /// <summary>
        /// Tamaño de la página.
        /// </summary>
        public int pageSize { get; private set; }

        /// <summary>
        /// Número total de páginas.
        /// </summary>
        public int totalPages { get; private set; }

        /// <summary>
        /// Página de inicio para la paginación.
        /// </summary>
        public int startPage { get; private set; }

        /// <summary>
        /// Página final para la paginación.
        /// </summary>
        public int endPage { get; private set; }

        /// <summary>
        /// Constructor de la clase Pagination.
        /// </summary>
        /// <param name="item">Lista de elementos en la página actual.</param>
        /// <param name="count">Número total de elementos.</param>
        /// <param name="initPage">Página inicial.</param>
        /// <param name="numberOfRecord">Número de registros por página.</param>
        public Pagination(List<T> item, int count, int initPage, int numberOfRecord)
        {
            this.initPage = initPage;
            this.pageSize = (int)Math.Ceiling(count / (double)numberOfRecord);
            this.AddRange(item);
            this.startPage = initPage - 5;
            this.endPage = initPage + 4;

            if (startPage <= 0)
            {
                this.endPage = this.endPage - (startPage - 1);
                this.startPage = 1;
            }

            if (this.endPage > this.pageSize)
            {
                // Establece el valor de endPage al tamaño de la página.
                this.endPage = this.pageSize;
                if (this.endPage > 10)
                {
                    // Si endPage es mayor que 10, establece startPage a endPage menos 9.
                    this.startPage = this.endPage - 9;
                }
            }
        }

        /// <summary>
        /// Propiedad que indica si hay páginas anteriores disponibles.
        /// </summary>
        public bool previousPages => initPage > 1;

        /// <summary>
        /// Propiedad que indica si hay páginas siguientes disponibles.
        /// </summary>
        public bool nextPages => initPage < pageSize;

        /// <summary>
        /// Método estático para crear una instancia de Pagination<T> de manera asíncrona.
        /// </summary>
        /// <param name="origin">Consulta de origen.</param>
        /// <param name="initPage">Página inicial.</param>
        /// <param name="numberOfRecord">Número de registros por página.</param>
        /// <returns>Una instancia de Pagination<T> con los elementos y la información de paginación.</returns>
        public static async Task<Pagination<T>> PaginationCreate(IQueryable<T> origin, int initPage, int numberOfRecord)
        {
            // Cuenta el número total de registros en la consulta.
            var count = await origin.CountAsync();

            // Obtiene los elementos de la página actual.
            var items = await origin.Skip((initPage - 1) * numberOfRecord).Take(numberOfRecord).ToListAsync();

            // Retorna una nueva instancia de Pagination<T> con los elementos y la información de paginación.
            return new Pagination<T>(items, count, initPage, numberOfRecord);
        }
    }
}