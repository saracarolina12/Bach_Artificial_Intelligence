from matplotlib.ticker import FuncFormatter
import numpy as np

class ParticleSwarmOptimization:
    def __init__(self, func, funcFeasible, bounds, nParticles, maxIter, args):
        assert isinstance(nParticles, int), 'nParticles is not int'
        assert isinstance(maxIter, int), 'maxIter is not int'
        assert callable(func), 'func is not function'
        assert callable(funcFeasible), 'funcFeasible is not function'
        bounds = np.array(bounds)
        assert isinstance(bounds, np.ndarray), 'bounds is not np.ndarray'
        args = np.array(args)
        assert isinstance(args, np.ndarray), 'args is not np.ndarray'
        self.nParticles = nParticles
        self.maxIter = maxIter
        self.func = func
        self.funcFeasible = funcFeasible
        self.bounds = bounds
        self.args = args 
        self.nVar = bounds.shape[0]
        self.w,self.c1,self.c2 = 0, 0, 0
        self.positions = None
        self.fitness = None
        self.pBest = None
        self.gBest = None
    def initSwarm(self):
        self.positions = np.zeros((self.nParticles, self.nVar))
        self.velocities = np.zeros((self.nParticles, self.nVar))
        for v in range(self.nVar):
            pMin, pMax = self.bounds[v, 0], self.bounds[v, 1]
            vMin, vMax = (pMin - pMax) / 10 + pMin, (pMax - pMin) / 10 + pMin
            self.positions[:, v] = np.random.uniform(pMin, pMax, (self.nParticles))
            self.velocities[:, v] = np.random.normal(0, (pMax - pMin) / 10, (self.nParticles))
        for p in range(self.nParticles):
            while not self.funcFeasible(self.positions[p]):
                for v in range(self.positions[p].shape[0]):
                    pMin, pMax = self.bounds[v, 0], self.bounds[v, 1]
                    self.positions[p, v] = np.random.uniform(pMin, pMax)

    def solve(self):
        return self._solve()
    def _solve(self):
        # Initialize 𝑐1, 𝑐2, 𝑤
        self.c1, self.c2, self.w, self.step = 0.9, 0.9, 0.9, 0.9/self.maxIter 
        # Create the particles positions and velocities randomly
        self.initSwarm()
        # Calculate the objective function values
        self.fitness = np.array([self.func(i) for i in self.positions])
        # Calculate 𝑃𝑏𝑒𝑠𝑡_𝑖 as the current positions
        self.pBest = np.copy(self.positions)
        # Calculate 𝐺𝑏𝑒𝑠𝑡
        self.gBest = np.argmax(self.fitness)
        # While t < MaxIter or we haven’t found a good solution
        # print(np.unique([self.funcFeasible(i) for i in self.positions], return_counts=True))
        for _ in range(self.maxIter):
            # For each particle 𝑖
            #print(self.pBest[self.gBest])
            for i in range(self.nParticles):
                # Update the velocity:
                # 𝑣 𝑖(𝑡 + 1) = 𝑤 𝑣 𝑖 (𝑡) + 𝑐1 𝑟1 ( 𝑃𝑏𝑒𝑠𝑡 𝑖 − 𝑥𝑖 (𝑡)) + 𝑐2 𝑟2 (𝐺𝑏𝑒𝑠𝑡 − 𝑥𝑖 (𝑡))
                r1, r2 = np.random.uniform(0, 1, (2))
                self.velocities[i] = self.w*self.velocities[i] + self.c1*r1*(self.pBest[i] - self.positions[i]) + self.c2*r2*(self.pBest[self.gBest] - self.positions[i])
                # Update the position:
                # 𝑥𝑖 (𝑡 + 1) = 𝑥𝑖 (𝑡) + 𝑣 𝑖 (𝑡 + 1)
                low, high, mid = 0, 1, 0.5
                while low < high:
                    nPos = mid*(self.positions[i] + self.velocities[i])
                    if self.funcFeasible(nPos) and not self.funcFeasible((mid + 0.01)*(self.positions[i] + self.velocities[i])):
                        break
                    elif self.funcFeasible(nPos): low = mid
                    else: high = mid
                    mid = (low + high)/2
                # print("funfeasible: ", self.funcFeasible(mid*(self.positions[i] + self.velocities[i])))
                # print("mid: ",mid)
                # print("nPos: ",mid*(self.positions[i] + self.velocities[i]))
                self.positions[i] = mid*(self.positions[i] + self.velocities[i])
                # Calculate 𝑓𝑢𝑛𝑐(𝑥𝑖 )
                self.fitness[i] = self.func(mid*(self.positions[i] + self.velocities[i]))
                # If 𝑓(𝑥𝑖 ) < 𝑓𝑢𝑛𝑐(𝑃𝑏𝑒𝑠𝑡𝑖 ): update 𝑃𝑏𝑒𝑠𝑡
                if self.func(self.pBest[i]) > self.fitness[i]: self.pBest[i] = self.positions[i].copy()
                # If 𝑓(𝑥𝑖 ) < 𝑓𝑢𝑛𝑐(𝐺𝑏𝑒𝑠𝑡): update 𝐺𝑏𝑒𝑠𝑡
                if self.func(self.pBest[self.gBest]) > self.fitness[i]: self.gBest = i
            # Decrease 𝑐1, 𝑐2,𝑤
            self.c1 -= self.step
            self.c2 -= self.step
            self.w -= self.step

        return {'sol': self.pBest[self.gBest], 'func': self.func(self.pBest[self.gBest])}
def particle_swarm_optimization(func, funcFeasible, bounds, nParticles = 25, maxIter = 100, args = ()):
    pS = ParticleSwarmOptimization(func, funcFeasible, bounds, nParticles, maxIter, args)
    return pS.solve()