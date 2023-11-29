namespace HostsPinger
{
	public interface IPingLogger
	{
		void LogStart(HostPinger host);

		void LogStatusChange(HostPinger host, HostStatus oldStatus, HostStatus newStatus);

		void LogStop(HostPinger host);
	}
}
