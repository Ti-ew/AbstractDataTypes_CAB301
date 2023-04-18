using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	private IJob[] jobs;
	private uint count;
	public JobCollection( uint capacity ) {
		if( !( capacity >= 1 ) ) throw new ArgumentException();
		jobs = new IJob[capacity];
        count = 0;
	}
	public uint Capacity {
		get { return (uint) jobs.Length; }
	}
	public uint Count {
		get { return count; }
	}
	public bool Add( IJob job ) {
        if (job == null) return false;//The JOB is NOT null
        if (Count >= Capacity) return false; //There is room
        if (Contains(job.Id)) return false; //The JOB ID does NOT exist       
        jobs[Count] = job; //Add the job to the jobs array
        count++; //Increase the count by one        
        return true; //Return True
    }
    public bool Contains(uint id) {
        for (int i = 0; i <= Count; i++){ //Go over the jobs array counting only the jobs and no empty spaces after (Capacity > count)         
            if (jobs[i]?.Id == id) { return true; } //Return true if the job id already exists                     
        }
        return false;//Otherwise it doesnt, return false
    }
    public IJob? Find( uint id ) {
        for (int i = 0; i < Count; i++) { //Go over the jobs array counting only the jobs and no empty spaces after (Capacity > count)        
            if (jobs[i].Id == id) {             
                return jobs[i];
            }
        }
        return null;
    }
    public bool Remove(uint id) {
        for (int i = 0; i < Count; i++) { //Go over the jobs array counting only the jobs and no empty spaces after (Capacity > count)
            if (jobs[i].Id == id) {            
                //Begin to copy the array item by item starting from the job to remove and shifting all jobs -1 index (to the right)
                for (int j = i; j < Count - 1; j++) {                
                    jobs[j] = jobs[j + 1];
                }
                jobs[Count - 1] = null;
                count--;
                return true;
            }
        }
        return false;
    }
    public IJob[] ToArray() {
        IJob[] copy = new IJob[jobs.Length];
        for (int i = 0; i < jobs.Length; i++) {
            copy[i] = jobs[i];
        }
        return copy;
    }
}
