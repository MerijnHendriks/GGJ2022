using UnityEngine;

public class Timer
{
    //The time stamp where the timer starts
    private float timeStamp;

    //The interval of the timer
    private float interval;

    //The time that still is left when the timer gets paused
    private float pauseDifference;

    //The pause state of the timer
    public bool isPaused { get; private set; }

    //Set the Timer when creating the time
    //public Timer(float interval)
    //{
    //    Set(interval);
    //}

    //Set the timer
    public void Set(float interval = 2)
    {
        //Set the current timestamp
        timeStamp = Time.time;
        //Set the interval
        this.interval = interval;
    }

    //Reset the timer
    public void Reset()
    {
        //Set the timer with the last interval to reset it
        Set(interval);
    }

    //Pause or Unpause the timer
    public void Pause(bool pause)
    {
        if (pause)
        {
            //Save time (to continue after unpause)
            pauseDifference = TimeLeft();
            isPaused = pause;
            //Set the pause state of the timer
            return;
        }

        //Unpause the timer
        isPaused = pause;
        timeStamp = Time.time - (interval - pauseDifference);
    }

    //Returns how long the timer still needs to run
    public float TimeLeft()
    {
        //Return the time that is left
        return Done() ? 0 : (1 - Progress()) * interval;
    }

    //Get the progress of the timer
    public float Progress()
    {
        //Calculate the progress of the timer
        return (isPaused) ? (interval - pauseDifference) / interval : Done() == true ? 1 : Mathf.Abs((timeStamp - Time.time) / interval);
    }

    //Check if the timer is done
    public bool Done()
    {
        //Return the status
        return (isPaused) ? pauseDifference == 0.0f : Time.time >= timeStamp + interval ? true : false;
    }
}