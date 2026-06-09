using UnityEngine;
using UnityEngine.AI;

public static class NavMeshAgentSafe
{
    private const float SampleDistance = 10f;

    public static bool EnsureOnNavMesh(NavMeshAgent agent)
    {
        if (agent == null || !agent.enabled)
        {
            return false;
        }
        if (agent.isOnNavMesh)
        {
            return true;
        }
        NavMeshHit hit;
        if (NavMesh.SamplePosition(agent.transform.position, out hit, SampleDistance, NavMesh.AllAreas))
        {
            return agent.Warp(hit.position);
        }
        return false;
    }

    public static bool SetDestination(NavMeshAgent agent, Vector3 destination)
    {
        if (!EnsureOnNavMesh(agent))
        {
            return false;
        }
        NavMeshHit hit;
        Vector3 target = destination;
        if (NavMesh.SamplePosition(destination, out hit, SampleDistance, NavMesh.AllAreas))
        {
            target = hit.position;
        }
        return agent.SetDestination(target);
    }

    public static bool ResetPath(NavMeshAgent agent)
    {
        if (!EnsureOnNavMesh(agent) || agent.isOnOffMeshLink)
        {
            return false;
        }
        if (agent.path != null)
        {
            agent.ResetPath();
        }
        return true;
    }
}
