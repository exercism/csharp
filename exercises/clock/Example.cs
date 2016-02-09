public struct Clock
{
    private int _hours;
    private int _minutes;

    public Clock(int hours, int minutes = 0)
    {
        _hours = hours;
        _minutes = minutes;
        Normalize();
    }

    public Clock Add(int minutes)
    {
        return new Clock(_hours, _minutes + minutes);
    }

    public Clock Subtract(int minutes)
    {
        return Add(-minutes);
    }

    public override string ToString()
    {
        return string.Format("{0:00}:{1:00}", _hours, _minutes);
    }

    private void Normalize()
    {
        if(_minutes >= 60)
        {
            _hours += _minutes / 60;
            _minutes = _minutes % 60;
        }
        while(_minutes < 0)
        {
            --_hours;
            _minutes += 60;
        }
        if(_hours >= 24)
        {
            _hours = _hours % 24;
        }
        while(_hours < 0)
            _hours += 24;
    }
}