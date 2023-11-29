class Counter 
{
    private:
        int _count; 

    public:
        Counter() 
        {
            _count = 0;
        }

        int Ticks()
        {
            return _count;
        }

        void Increment() 
        { 
            _count++; 
        }

        void Reset() 
        { 
            _count = 0; 
        }
};