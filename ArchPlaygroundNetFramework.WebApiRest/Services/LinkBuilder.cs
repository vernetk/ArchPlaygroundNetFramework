using ArchPlaygroundNetFramework.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchPlaygroundNetFramework.WebApiRest.Services
{
    public class LinkBuilder
    {
        private HttpRequest Request => HttpContext.Current?.Request;

        private string Url(string path)
        {
            if (Request == null) return path;

            var root = $"{Request.Url.Scheme}://{Request.Url.Authority}";
            return root + path;
        }

        public object Vehicule(int id) =>
            new { href = Url($"/api/vehicules/{id}") };

        public object PagedVehicules(VehiculeSearchCriteria c, int totalCount)
        {
            int totalPages = (int)Math.Ceiling(totalCount / (double)c.PageSize);

            return new
            {
                self = Url($"/api/vehicules{BuildQuery(c.Page, c)}"),
                next = c.Page < totalPages ? Url($"/api/vehicules{BuildQuery(c.Page + 1, c)}") : null,
                prev = c.Page > 1 ? Url($"/api/vehicules{BuildQuery(c.Page - 1, c)}") : null,
                first = Url($"/api/vehicules{BuildQuery(1, c)}"),
                last = Url($"/api/vehicules{BuildQuery(totalPages, c)}")
            };
        }

        private string BuildQuery(int page, VehiculeSearchCriteria c)
        {
            string query = $"?page={page}&pageSize={c.PageSize}";

            if (!string.IsNullOrEmpty(c.Marque)) query = query + $"&marque={c.Marque}";
            if (!string.IsNullOrEmpty(c.Modele)) query = query + $"&modele={c.Modele}";
            if (c.AnneeMin.HasValue) query = query + $"&anneemin={c.AnneeMin.Value}";
            if (c.AnneeMax.HasValue) query = query + $"&anneemax={c.AnneeMax.Value}";
            if (c.PrixMin.HasValue) query = query + $"&prixmin={c.PrixMin.Value}";
            if (c.PrixMax.HasValue) query = query + $"&prixmax={c.PrixMax.Value}";
            if (!string.IsNullOrEmpty(c.Marque)) query = query + $"&marque={c.Marque}";
            if (!string.IsNullOrEmpty(c.Marque)) query = query + $"&marque={c.Marque}";

            return query;
        }
    }

}