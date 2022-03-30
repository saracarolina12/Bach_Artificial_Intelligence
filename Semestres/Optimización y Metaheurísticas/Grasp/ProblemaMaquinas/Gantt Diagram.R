install.packages('devtools')
#devtools::install_github('Kitware/candela', subdir='R/candela', dependencies = TRUE)

library(candela)

buildDiagrms <- function(solution, prosecutionTime, adjustmentTime)
{
  data = list()
  i = 1
  different = 0
  for(n in 1:length(solution))
  {
    time = 0
    if(n %% 2 == 1) different = 1
    else different = 2
    for(m in 1:length(solution[[n]]))
    {
      print(data)
      if(m >= 2)
      {
        data[[i]] = list(name=gsub(" ", "", paste("A",solution[[n]][m-1])), level=different, start=time, end=time+adjustmentTime[[n]][solution[[n]][m-1],solution[[n]][m]])
        time = time + adjustmentTime[[n]][solution[[n]][m-1],solution[[n]][m]]
        #data[[i]] = list(name=gsub(" ", "", paste("A",solution[[n]][m-1])), level=different, start=time-adjustmentTime[[n]][solution[[n]][m-1],solution[[n]][m]], end=time)
        i = i + 1
      }
      data[[i]] = list(name=gsub(" ", "", paste("O",solution[[n]][m])), level=different, start=time, end=time+prosecutionTime[n,solution[[n]][m]])
      time = time + prosecutionTime[n,solution[[n]][m]]
      i = i + 1
    }
  }
  return(data)
}

data = buildDiagrms(initialSol,prosecutionTime,list(adjustmentTime01,adjustmentTime02))

candela('GanttChart',
        data=data, label='name',
        start='start', end='end', level='level')
