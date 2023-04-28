namespace EmpDeptCrudSearch.Utilities {
    public class ResponseApi<T> {
        public bool? status { get; set; }
        public string? msg { get; set; }
        public T? Value { get; set; }
    }
}
