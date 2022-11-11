import numpy as np

class DifferentialEvolution:
    def __init__(self, func, bounds, popSize, cR, nMax, args):
        assert callable(func), 'func is not function'
        bounds = np.array(bounds)
        assert isinstance(bounds, np.ndarray), 'bounds is not np.ndarray'
        args = np.array(args)
        assert isinstance(args, np.ndarray), 'args is not np.ndarray'
        assert isinstance(popSize, int), 'popSize is not int'
        assert isinstance(cR, float), 'cR is not float'
        assert isinstance(nMax, int), 'nMax is not int'
        self.func = func
        self.bounds = bounds
        self.args = args 
        self.popSize = popSize
        self.cR = cR        #The bigger cR is, the more risk we take
        self.nMax = nMax
        self.nVar = bounds.shape[0]
        self.nF = 0         #Evaluations of the function
        self.nIt = 0        #Number of iterations
        self.fitness = None
        self.population = None

    def getFitness(self, i):
        assert isinstance(i, np.ndarray), 'individual is not np.ndarray'
        assert i.shape[0] == self.nVar, "individual doesn't have size == nVar"
        r = self._getFitness(i)
        return r
    def _getFitness(self, i):
        self.nF += 1
        return self.func(i, *self.args)

    def mutation(self):
        r = self._mutation()
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def _mutation(self):
        rand = np.random.randint(low = 0, high = self.popSize, size = 3)
        r1, r2, r3 = self.population[rand]
        F = np.random.uniform(0, 2)
        r = np.add(r1, F*np.subtract(r2, r3))
        r = [np.min((np.max((v, self.bounds[i, 0])), self.bounds[i, 1])) for i, v in enumerate(r)]
        return np.array(r)

    def crossover(self, pOne, pTwo):
        assert isinstance(pOne, np.ndarray), 'pOne is not np.ndarray'
        assert isinstance(pTwo, np.ndarray), 'pTwo is not np.ndarray'
        r = self._crossover(pOne, pTwo)
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def _crossover(self, pOne, pTwo):
        r = [pOne[i] if np.random.rand() >= self.cR else pTwo[i] for i in range(pOne.shape[0])]
        return np.array(r)

    def selection(self, x, u): 
        assert isinstance(x, int), 'x is not int'               #Index of the already existing individual
        assert isinstance(u, np.ndarray), 'u is not np.ndarray' #New individual
        self._selection(x, u)
    def _selection(self, x, u):
        f = self.getFitness(u)
        if f < self.fitness[x]: 
            self.fitness[x] = f
            self.population[x] = np.copy(u)

    def initPopulation(self):
        self.population = np.zeros((self.popSize, self.nVar))
        for v in range(self.nVar):
            vMin, vMax = self.bounds[v, 0], self.bounds[v, 1]
            self.population[:, v] = np.random.uniform(vMin, vMax, (self.popSize))
        self.fitness = np.array([self.getFitness(i) for i in self.population])
    
    def solve(self):
        r = self._solve()
        assert isinstance(r, dict), 'r is not dict'
        return r
    def _solve(self):
        self.initPopulation()
        for _ in range(self.nMax):
            self.nIt += 1
            for i, individual in enumerate(self.population):
                u = self.crossover(individual, self.mutation())
                self.selection(i, u)
            if len(np.unique(self.fitness)) == 1: break
        best = np.argmin(self.fitness)
        
        return {"P": self.population[best], "nIt": self.nIt, "fun": self.fitness[best], "nFev": self.nF}
    
def differential_evolution(func, bounds, popSize, cR, nMax, args = ()):
    dE = DifferentialEvolution(func, bounds, popSize, cR, nMax, args)
    return dE.solve()