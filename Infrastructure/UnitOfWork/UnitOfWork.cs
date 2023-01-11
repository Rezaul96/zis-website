using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        private IEventSequenceObjectRepository _eventSequenceObjectRepository;
        private IBroadcastImageRepository _broadcastImageRepository;
        private ICompanyRepository _companyRepository;
        private IEventObjectDetailRepository _eventObjectDetailRepository;
        private IEventObjectRepository _eventObjectRepository;
        private IEventRepository _eventRepository;
        private IEventScorerecordRepository _eventScorerecordRepository;
        private IIndustryRepository _industryRepository;
        private IObjectTypeRepository _objectTypeRepository;
        private IParticipantImageRepository _participantImageRepository;
        private IRegionRepository _regionRepository;
        private ISequenceObjectRepository _sequenceObjectRepository;
        private ISequenceRepository _sequenceRepository;
        private ITeamMemberRepository _teamMemberRepository;
        private ITeamRepository _teamRepository;
        private IMemberRepository _memberRepository;
        private IEventShareRepository _eventShareRepository;


        public UnitOfWork(ApplicationContext context)
        {
            _dbContext = context;
        }
        public IEventShareRepository EventShareRepository { get { return _eventShareRepository = _eventShareRepository ?? new EventShareRepository(_dbContext); } }
        public IEventSequenceObjectRepository EventSequenceObjectRepository { get { return _eventSequenceObjectRepository = _eventSequenceObjectRepository ?? new EventSequenceObjectRepository(_dbContext); } }
        public IMemberRepository MemberRepository { get { return _memberRepository = _memberRepository ?? new MemberRepository(_dbContext); } }
        public IBroadcastImageRepository BroadcastImageRepository { get { return _broadcastImageRepository = _broadcastImageRepository ?? new BroadcastImageRepository(_dbContext); } }
        public ICompanyRepository CompanyRepository { get { return _companyRepository = _companyRepository ?? new CompanyRepository(_dbContext); } }
        public IEventObjectDetailRepository EventObjectDetailRepository { get { return _eventObjectDetailRepository = _eventObjectDetailRepository ?? new EventObjectDetailRepository(_dbContext); } }
        public IEventObjectRepository EventObjectRepository { get { return _eventObjectRepository = _eventObjectRepository ?? new EventObjectRepository(_dbContext); } }
        public IEventRepository EventRepository { get { return _eventRepository = _eventRepository ?? new EventRepository(_dbContext); } }
        public IEventScorerecordRepository EventScorerecordRepository { get { return _eventScorerecordRepository = _eventScorerecordRepository ?? new EventScorerecordRepository(_dbContext); } }
        public IIndustryRepository IndustryRepository { get { return _industryRepository = _industryRepository ?? new IndustryRepository(_dbContext); } }
        public IObjectTypeRepository ObjectTypeRepository { get { return _objectTypeRepository = _objectTypeRepository ?? new ObjectTypeRepository(_dbContext); } }
        public IParticipantImageRepository ParticipantImageRepository { get { return _participantImageRepository = _participantImageRepository ?? new ParticipantImageRepository(_dbContext); } }
        public IRegionRepository RegionRepository { get { return _regionRepository = _regionRepository ?? new RegionRepository(_dbContext); } }
        public ISequenceObjectRepository SequenceObjectRepository { get { return _sequenceObjectRepository = _sequenceObjectRepository ?? new SequenceObjectRepository(_dbContext); } }
        public ISequenceRepository SequenceRepository { get { return _sequenceRepository = _sequenceRepository ?? new SequenceRepository(_dbContext); } }
        public ITeamMemberRepository TeamMemberRepository { get { return _teamMemberRepository = _teamMemberRepository ?? new TeamMemberRepository(_dbContext); } }
        public ITeamRepository TeamRepository { get { return _teamRepository = _teamRepository ?? new TeamRepository(_dbContext); } }


        public void Commit()
              => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
       
    }
}
