#include <sstream>
#include <iomanip>
#include "Counter.cpp"

class Clock 
{
    private:
        Counter hours, minutes, seconds;

    public:
        std::string GetTimeString() 
        {
            std::ostringstream oss;  // Use for string formatting
            // Formatted output to ensure two digits with leading zeros if necessary
            oss << std::setw(2) << std::setfill('0') << hours.Ticks() << ":"
                << std::setw(2) << std::setfill('0') << minutes.Ticks() << ":"
                << std::setw(2) << std::setfill('0') << seconds.Ticks();
            return oss.str();  // Convert stream to string and return
        }

        void Ticks() 
        {
            seconds.Increment(); 
            if (seconds.Ticks() >= 60) 
            {
                minutes.Increment();
                seconds.Reset();
            }
            if (minutes.Ticks() >= 60) 
            {
                hours.Increment();
                minutes.Reset();
            }
            if (hours.Ticks() >= 24) 
            {
                hours.Reset();
            }
        }

        void Reset() 
        {
            hours.Reset();
            minutes.Reset();
            seconds.Reset();
        }
};
