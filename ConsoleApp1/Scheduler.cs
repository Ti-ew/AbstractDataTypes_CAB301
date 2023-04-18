using System;

public class Scheduler : IScheduler
{
    public Scheduler(IJobCollection jobs)
    {
        Jobs = jobs;
    }

    public IJobCollection Jobs { get; }

    public IJob[] FirstComeFirstServed() { 
    /*----------------returns an array of IJob[] type  sorted in non-descending order of Time Received----------------------*/
    /*----------------Example: 1,2,2,2,3,4,5,6,7,8,9----------------------*/
    
        IJob[] jobsCopy = Jobs.ToArray();//Create a copy of the array to manipulate
        Comparison<IJob> compareFCFS = new Comparison<IJob>(CompareTimeReceived);
        SelectionSort(jobsCopy, compareFCFS);//Use the copy and sort it by FCFS
        return jobsCopy;//Return the sorted array
    }
    public IJob[] Priority() { 
    /*----------------returns an array of IJob[] type  sorted in non-ascending order of Priority----------------------*/
    /*----------------Example: 9,9,8,7,6,5,4,3,2,1----------------------*/    
        IJob[] jobsCopy = Jobs.ToArray();//Create a copy of the array to manipulate
        Comparison<IJob> comparePrio = new Comparison<IJob>(ComparePriority);
        SelectionSort(jobsCopy, comparePrio);//Use the copy and sort it by Priority
        return jobsCopy;//Return the sorted array
    }
    public IJob[] ShortestJobFirst() { 
    /*----------------returns an array of IJob[] type  sorted in non-descending order of Execution Time----------------------*/
    /*----------------Example: 1,2,3,4,5,6,7,7,8,9----------------------*/
    
        IJob[] jobsCopy = Jobs.ToArray();//Create a copy of the array to manipulate        
        Comparison<IJob> compareSJF = new Comparison<IJob>(CompareExecutionTime);
        SelectionSort(jobsCopy, compareSJF);//Use the copy and sort it by Execution Time
        return jobsCopy;//Return the sorted array
    }   
    private int ComparePriority(IJob x, IJob y) {
        if (x == null) return 0;
        return x.Priority.CompareTo(y.Priority)*-1;//Times by negative one to flip the comparison values (look for larger)
    }
    private int CompareExecutionTime(IJob x, IJob y) {
        if (x == null) return 0;
        return x.ExecutionTime.CompareTo(y.ExecutionTime);
    }
    private int CompareTimeReceived(IJob x, IJob y) {
        if (x == null) return 0;
        return x.TimeReceived.CompareTo(y.TimeReceived);
    }
    private void SelectionSort(IJob[] jobsArray, Comparison<IJob> comparison) { 
    /*----------------Begin selection sort algorithm----------------------*/
        for (int i = 0; i < jobsArray.Length-1; i++){ //For every item in the jobsArray list        
            int minIndex = i;//Set the minimum value as the first value
            for (int j = i + 1; j < jobsArray.Length; j++) {                
                //Iterate over the array starting from the second item in the array            
                if (comparison(jobsArray[j], jobsArray[minIndex]) == -1 ||//If the j'th item is less than the minIndex'th item OR
                    (jobsArray[j] == jobsArray[minIndex] && j < minIndex)) { //If the items are equal, use the indicies to decide wether to swap or not                
                    minIndex = j;//Set the minIndex to the indicie of the item in question
                }
            }
            if (minIndex != i) { //If the smallest number in the array is not the first, begin the swap process            
                IJob temp = jobsArray[i];
                jobsArray[i] = jobsArray[minIndex];
                jobsArray[minIndex] = temp;
            }
        }
    }  
}