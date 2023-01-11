using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEventShareRepository EventShareRepository { get; }
        IEventSequenceObjectRepository EventSequenceObjectRepository { get; }
        IBroadcastImageRepository BroadcastImageRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IEventObjectDetailRepository EventObjectDetailRepository { get; }
        IEventObjectRepository EventObjectRepository { get; }
        IEventRepository EventRepository { get; }
        IEventScorerecordRepository EventScorerecordRepository { get; }
        IIndustryRepository IndustryRepository { get; }
        IObjectTypeRepository ObjectTypeRepository { get; }
        IParticipantImageRepository ParticipantImageRepository { get; }
        IRegionRepository RegionRepository { get; }
        ISequenceObjectRepository SequenceObjectRepository { get; }
        ISequenceRepository SequenceRepository { get; }
        ITeamMemberRepository TeamMemberRepository { get; }
        ITeamRepository TeamRepository { get; }
        IMemberRepository MemberRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
