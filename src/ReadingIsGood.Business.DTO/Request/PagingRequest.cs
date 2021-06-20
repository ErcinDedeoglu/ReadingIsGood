namespace ReadingIsGood.Business.DTO.Request
{
    public class PagingRequest
    {
        private int _page;
        private int _quantity;
        private int _skip;

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0) _quantity = 1;
                else if (value > 50) _quantity = 50;
                else _quantity = value;

                if (_quantity > 1) _skip = _quantity * (_page - 1);
                else _skip = 0;
            }
        }
        
        public int Skip
        {
            get => _skip;
            set => _skip = value;
        }
    }
}