namespace Model
{
    public partial class Contact
    {
        public Contact()
        { }

        #region Model

        private string _id;

        private string _table;
        private string _scrap_state;

        public string Scrap_state
        {
            get { return _scrap_state; }
            set { _scrap_state = value; }
        }
        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _departments;

        public string Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }
        private string _situation;

        public string Situation
        {
            get { return _situation; }
            set { _situation = value; }
        }
        private int _repair_report;

        public int Repair_report
        {
            get { return _repair_report; }
            set { _repair_report = value; }
        }
        private string _buy_time;

        public string Buy_time
        {
            get { return _buy_time; }
            set { _buy_time = value; }
        }
        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private string _decrease_sum;

        public string Decrease_sum
        {
            get { return _decrease_sum; }
            set { _decrease_sum = value; }
        }
        private string _accumulated_depreciation;

        public string Accumulated_depreciation
        {
            get { return _accumulated_depreciation; }
            set { _accumulated_depreciation = value; }
        }
        private string _surplus_value;

        public string Surplus_value
        {
            get { return _surplus_value; }
            set { _surplus_value = value; }
        }
        private string _discard_time;

        public string Discard_time
        {
            get { return _discard_time; }
            set { _discard_time = value; }
        }
        private string _initial_recorder;

        public string Initial_recorder
        {
            get { return _initial_recorder; }
            set { _initial_recorder = value; }
        }
        private string _now;

        public string Now
        {
            get { return _now; }
            set { _now = value; }
        }
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _recorder;

        public string Recorder
        {
            get { return _recorder; }
            set { _recorder = value; }
        }
        private string _inspecter;

        public string Inspecter
        {
            get { return _inspecter; }
            set { _inspecter = value; }
        }
        private string _reason;

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        private string _start_time;

        public string scrap_date
        {
            get { return _start_time; }
            set { _start_time = value; }
        }
        private string _end_time;

        public string End_time
        {
            get { return _end_time; }
            set { _end_time = value; }
        }
        private string _dtenant;

        public string Dtenant
        {
            get { return _dtenant; }
            set { _dtenant = value; }
        }
        private string _money;

        public string Money
        {
            get { return _money; }
            set { _money = value; }
        }
        private string _repair_reason;

        public string Repair_reason
        {
            get { return _repair_reason; }
            set { _repair_reason = value; }
        }
        private string _buy_price;

        public string Buy_price
        {
            get { return _buy_price; }
            set { _buy_price = value; }
        }
        private string _buy_date;

        public string Buy_date
        {
            get { return _buy_date; }
            set { _buy_date = value; }
        }
        private string _scrap_date;

        public string Scrap_date
        {
            get { return _scrap_date; }
            set { _scrap_date = value; }
        }
        private string _sum;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        private string _old_departments;

        public string Old_departments
        {
            get { return _old_departments; }
            set { _old_departments = value; }
        }
        private string _old_start_time;

        public string Old_start_time
        {
            get { return _old_start_time; }
            set { _old_start_time = value; }
        }
        private string _old_end_time;

        public string Old_end_time
        {
            get { return _old_end_time; }
            set { _old_end_time = value; }
        }

        private string _old_money;

        public string Old_money
        {
            get { return _old_money; }
            set { _old_money = value; }
        }
        #endregion Model
        private string _old_date;

        public string Old_date
        {
            get { return _old_date; }
            set { _old_date = value; }
        }
        private string _old_name;

        public string Old_name
        {
            get { return _old_name; }
            set { _old_name = value; }
        }
        private string _tenant;

        public string Tenant
        {
            get { return _tenant; }
            set { _tenant = value; }
        }
        private string _old_tenant;

        public string Old_tenant
        {
            get { return _old_tenant; }
            set { _old_tenant = value; }
        }
    }
}
